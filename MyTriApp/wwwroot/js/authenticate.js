function authenticate() {
    const clientId = "111830";
    const redirectUrl = "https://localhost:7201/homepage.html";
    const scope = "read";

    window.location = `https://www.strava.com/oauth/authorize?client_id=${clientId}&response_type=code&redirect_uri=${redirectUrl}&approval_prompt=force&scope=${scope}`;
}

authenticate();