var chat = chat || {};

chat.UserList = function (config) {
    var self = this;

    self.users = ko.observableArray([]);
    self.name = ko.observable();

    self.addUser = function () {        
        var user = { Id: null, Name: self.name() };
        chat.AjaxService.postJSON(config.addUserApiUrl, ko.toJSON(user))
            .done(function (data) {
                self.users.push(user);
            });
    }

    function _callback(data){
      if (data)
        self.users(data);
    }

    new chat.PollingService(config.pollApiUrl, _callback)

};