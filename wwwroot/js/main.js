// Funktion för att växla mellan ljust och mörkt tema.
function toggleTheme() {

    // Hämtar  aktuellt tema från sessionStorage.
    let themeNow = sessionStorage.getItem("theme");

    // Är temat mörkt? Då byts det till ljust och tvärtom.
    if (themeNow === "dark") {
        // Sätter temat till ljust.
        sessionStorage.setItem("theme", "light");
    } else {
        // Sätter temat till mörkt.
        sessionStorage.setItem("theme", "dark");
    }

    // Anropar funktionen applyTheme för att applicera aktuellt tema.
    applyTheme();
}

// Funktion för att applicera temat vid växling.
function applyTheme() {

    // Hämtar aktuellt tema.
    let theme = sessionStorage.getItem("theme");

    // Om inget tema är lagrat i sessionStorage, är default ljust tema.
    if (!theme) {
        theme = "light";
        sessionStorage.setItem("theme", theme);
    }

    // Uppdaterar klasserna utifrån valt tema.
    document.body.classList.toggle("dark-theme", theme === "dark");
    document.body.classList.toggle("light-theme", theme === "light");
}

// Kör funktionen applyTheme vid sidladdning för att säkerställa att default är ljust.
window.onload = applyTheme;