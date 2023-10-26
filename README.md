# Conversation_With_Gen_AI
Conversation With Gen AI is a Windows Form App written in C# and .Net 7 to demo integrations between Azure Speech Service and Azure Open AI.

In order to run this application you'd need an **Azure Speech Service** resource and an **Azure Open AI** resource.

To run this application locally, clone the repo, then add a new config file called App.config with the following format
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
		<add key="SubscriptionKey" value="Your Speech Service key"/>
		<add key="AzureRegion" value="The Azure region Speech Service is deployed to"/>
		<add key="OpenAiUri" value="Your Azure Open AI endpoint uri"/>
		<add key="OpenAiKey" value="Your Azure Open AI key"/>
		<add key="VoiceName" value="Name of the voice you'd like to use"/>
	</appSettings>
</configuration>
```

For supported voices please visit [Language and voice support for the Speech service](https://learn.microsoft.com/en-us/azure/ai-services/speech-service/language-support?tabs=tts)
