function UserRegister() {
    _this = this;

    this.init = function () {
    }
}

var userRegister = null;
$().ready(function () {
    userRegister = new UserRegister();
    userRegister.init();
});