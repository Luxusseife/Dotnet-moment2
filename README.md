# Moment 2 - Webbutveckling med .NET

Min lösning är en bokinventeringsapp. Här kan användaren lägga till böcker i sin samling med titel, författare, utgivningsår och ifall boken är läst eller ej. I formuläret finns validering som gör att tomma fält ej kan lagras och att utgivningsår behöver vara inom en viss range. Vid lyckad lagring hamnar boken i tabellen i vyn My books. Där finns möjlighet att radera boken om man önskar. 

För detta moment har MVC-mönstret implementerats med en strukturerad modell i form av properties, tre olika vyer dit data skickas med bland annat viewData() och viewBag() samt en controller som fungerar som en mellanhand mellan modellen och vyn. Här hanteras logik gällande validering, inläsning av json-data och lagring av json-data. Här hanteras även radering av data. 

Appen ger användaren möjlighet att byta till mörkt tema via en knapp i footern. Ljust tema är default. Användarens val av tema lagras i sessionStorage och finns alltså kvar så länge webbläsaren hålls öppen. 

_Skapad av Jenny Lind, jeli2308._