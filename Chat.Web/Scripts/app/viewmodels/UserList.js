var chat = chat || {};

chat.UserList = function (config) {
    var self = this;

    self.users = ko.observableArray([]);
    self.name = ko.observable();

    self.addUser = function () {
        _load();
        var user = { Id: null, Name: self.name() };
        config.ajaxService.postJSON(config.addUserApiUrl, ko.toJSON(user))
            .done(function (data) {
                self.users.push(user);
            });
    }

    function _load() {
        config.ajaxService.getJSON(config.usersApiUrl)
            .done(function (data) {
                if (data)
                    self.users(data);
            })
            .fail(function () {

            });
    };

    _load();

};