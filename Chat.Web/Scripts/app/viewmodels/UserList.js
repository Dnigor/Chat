var chat = chat || {};

chat.UserList = function (config) {
    var self = this;

    self.users       = ko.observableArray([]);
    self.sendTextbox = ko.observable();
    self.publicMessage = ko.observable();
    
    self.publicMessage.subscribe(function (value) {
        var publicContent = $('#publicContent').val();
        if (publicContent) 
            $('#publicContent').val(publicContent + '\r\n' + value);        
        else
            $('#publicContent').val(value);

    });
    
    //self.name = ko.observable();

    //self.addUser = function () {        
    //    var user = { Name: self.name() };
    //    chat.AjaxService.postJSON(config.addUserApiUrl, ko.toJSON(user))
    //        .done(function (data) {
    //            self.users.push(user);
    //        });
    //}

    self.sendMessage = function (receiver) {
      var sendMessageCommand = {
        sender   : config.name,
        receiver : receiver,
        content  : self.sendTextbox()
      };
      config.ajaxService.postJSON(config.sendMessageApiUrl, sendMessageCommand);
      self.sendTextbox('');
    }

    function _callback(data) {
        ko.mapping.fromJS(data, {}, self);      
    }

    var pollingService = new chat.PollingService(config.ajaxService, config.pollApiUrl, _callback);
    pollingService.poll();

    setTimeout(function () { config.ajaxService.postJSON(config.getUsersApiUrl, { sender: config.name }) }, 100);

};