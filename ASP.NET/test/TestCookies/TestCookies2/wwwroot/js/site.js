function setCookie() {
    var dt = new Date();
    dt.setFullYear(dt.getFullYear() + 1);
    document.cookie = "TestCookiesFromClient=TestCookiesFromClient;expires=" + dt.toGMTString();
}