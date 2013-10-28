var chat = chat || {};

chat.UserList = function (config) {
    var self = this;

    self.users       = ko.observableArray([]);
    self.sendTextbox = ko.observable();
    self.publicContent = ko.observable();
    //self.name = ko.observable();

    //self.addUser = function () {        
    //    var user = { Name: self.name() };
    //    chat.AjaxService.postJSON(config.addUserApiUrl, ko.toJSON(user))
    //        .done(function (data) {
    //            self.users.push(user);
    //        });
    //}

    self.sendMessage = function () {
      var sendMessageCommand = {
        sender   : config.name,                   
        content  : self.sendTextbox()
      };
      config.ajaxService.postJSON(config.sendMessageApiUrl, sendMessageCommand);
    }

    function _callback(data) {
        ko.mapping.fromJS(data, {}, self);
        //if (data) {
        //    self.users(data.Users);
        //    self.publicContent(data.PublicContent);
        //}
    }

    var pollingService = new chat.PollingService(config.ajaxService, config.pollApiUrl, _callback);
    pollingService.poll();

    setTimeout(function () { config.ajaxService.postJSON(config.getUsersApiUrl, { sender: config.name }) }, 100);

};