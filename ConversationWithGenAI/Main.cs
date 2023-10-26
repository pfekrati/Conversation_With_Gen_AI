using Azure.AI.OpenAI;
using Azure;
using Microsoft.CognitiveServices.Speech;
using OpenAI_API;
using OpenAI_API.Moderation;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;

namespace ConversationWithGenAI
{
    public partial class Main : Form
    {
        private const string SubscriptionKey = "";
        private const string CloudRegion = "";
        private const string OpenAiUri = "";
        private const string OpenAiKey = "";
        private const string VoiceName = "";
        bool start;
        SpeechConfig recognizerConfig;
        SpeechConfig speechConfig;
        SpeechRecognizer recognizer;
        SpeechSynthesizer synthesizer;
        OpenAIClient openApiClient;
        public Main()
        {
            InitializeComponent();
        }

        private async void btn_start_stop_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                start = true;
                btn_start_stop.BackColor = Color.Red;
                btn_start_stop.Text = "Stop";
                InitializeObjects();
                await StartConversation();
            }
            else
            {
                start = false;
                btn_start_stop.BackColor = Color.Green;
                btn_start_stop.Text = "Start";
                await DisposeObjects();
            }
        }

        private void InitializeObjects()
        {
            recognizerConfig = SpeechConfig.FromSubscription(SubscriptionKey, CloudRegion);
            recognizer = new SpeechRecognizer(recognizerConfig);
            speechConfig = SpeechConfig.FromSubscription(SubscriptionKey, CloudRegion);
            speechConfig.SpeechSynthesisVoiceName = VoiceName;
            synthesizer = new SpeechSynthesizer(speechConfig);
            openApiClient = new OpenAIClient(new Uri(OpenAiUri), new AzureKeyCredential(OpenAiKey));
        }

        private async Task DisposeObjects()
        {
            try
            {
                await synthesizer.StopSpeakingAsync();
                recognizer.Dispose();
                synthesizer.Dispose();
            }
            catch
            {

            }
        }

        private async Task StartConversation(ChatCompletionsOptions chatOptions = null)
        {
            if (recognizer != null && synthesizer != null)
            {
                var result = await recognizer.RecognizeOnceAsync();
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    txt_question.Text = result.Text;

                    if (chatOptions == null)
                    {
                        chatOptions = new ChatCompletionsOptions()
                        {
                            Temperature = (float)0.7,
                            MaxTokens = 800,
                            NucleusSamplingFactor = (float)0.95,
                            FrequencyPenalty = 0,
                            PresencePenalty = 0,
                        };
                    }

                    chatOptions.Messages.Add(new ChatMessage(ChatRole.User, result.Text));

                    Response<ChatCompletions> responseWithoutStream = await openApiClient.GetChatCompletionsAsync("gpt-35", chatOptions);
                    ChatCompletions completions = responseWithoutStream.Value;

                    txt_answer.Text = completions.Choices.First().Message.Content;

                    lbl_aiSpeaking.Visible = true;
                    var speechResult = await synthesizer.SpeakTextAsync(txt_answer.Text);
                    if (speechResult.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        lbl_aiSpeaking.Visible = false;
                        chatOptions.Messages.Add(new ChatMessage(ChatRole.Assistant, txt_answer.Text));
                        if (start)
                            await StartConversation(chatOptions);
                    }
                    else if (speechResult.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(speechResult);
                        txt_answer.Text = $"CANCELED: Reason={cancellation.Reason}";

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            txt_answer.Text = $"CANCELED: ErrorCode={cancellation.ErrorCode}";
                            txt_answer.Text = txt_answer.Text + Environment.NewLine + $"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]";
                            txt_answer.Text = txt_answer.Text + Environment.NewLine + $"CANCELED: Did you update the subscription info?";
                        }
                    }
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    txt_answer.Text = $"NOMATCH: Speech could not be recognized.";
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    txt_answer.Text = $"CANCELED: Reason={cancellation.Reason}";

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        txt_answer.Text = $"CANCELED: ErrorCode={cancellation.ErrorCode}";
                        txt_answer.Text = txt_answer.Text + Environment.NewLine + $"CANCELED: ErrorDetails={cancellation.ErrorDetails}";
                        txt_answer.Text = txt_answer.Text + Environment.NewLine + $"CANCELED: Did you update the subscription info?";
                    }
                }
            }

        }

        private void chk_showTexts_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_showTexts.Checked)
            {
                pnl_texts.Visible = true;
                this.Height = 454;
            }
            else
            {
                pnl_texts.Visible = false;
                this.Height = 190;
            }
        }
    }
}
