var chat = chat || {};

chat.Main = function (config) {
    var self = this;

    self.users = ko.observableArray([]);
    self.privateRooms = ko.observableArray([]);
    self.activeRoom = ko.observable();
    self.sendTextbox = ko.observable();
    self.sendPrivateTextbox = ko.observable();
    self.publicMessage = ko.observable();
    self.privateMessage = ko.observable();
    
    self.publicMessage.subscribe(function (value) {        
        var publicContent = $('#publicContent').val();
        if (publicContent) 
            $('#publicContent').val(publicContent + '\r\n' + value);        
        else
            $('#publicContent').val(value);
    });

    self.privateMessage.subscribe(function (value) {        
        var room = self.createPrivateRoom(value.sender());

        if (room.name !== self.activeRoom().name) {
            var count = room.unreadMessagesCount();
            room.unreadMessagesCount(count+1);
        }

        var message = value.content();
        _updateContent(room, message);               
    });

    function _updateContent(room, message) {
        with (room) {
            var currentContent = content();
            if (currentContent)
                content(currentContent + '\r\n' + message);
            else
                content(message);
        }
    }  

    //self.addUser = function () {        
    //    var user = { Name: self.name() };
    //    chat.AjaxService.postJSON(config.addUserApiUrl, ko.toJSON(user))
    //        .done(function (data) {
    //            self.users.push(user);
    //        });
    //}
    self.createPrivateRoom = function (name, active) {
        var room = _getRoom(name);
        if (!room) {
            var room = new chat.PrivateRoom(name);
            if (active)
                self.activeRoom(room);
            self.privateRooms.push(room);
        }
        else if (active)
            self.activeRoom(room);

        return room;
    }

    function _getRoom(name) {
        var room;
        $.each(self.privateRooms(), function (index, value) {
            if (value.name == name) {
                room = value;
                return false;
            }
        });
        return room;
    }

    self.setActiveRoom = function (room) {
        self.activeRoom(room);
        room.unreadMessagesCount(0);
    };

    self.sendMessage = function () {
      var sendMessageCommand = {
        sender   : config.name,      
        content  : self.sendTextbox()
      };
      config.ajaxService.postJSON(config.sendMessageApiUrl, sendMessageCommand);
      self.sendTextbox('');
    }

    self.sendPrivateMessage = function () {
        _updateContent(self.activeRoom(), config.name + ': ' + self.sendPrivateTextbox());
        var sendMessageCommand = {
            sender: config.name,
            receiver: self.activeRoom().name,
            content: self.sendPrivateTextbox()
        };
        config.ajaxService.postJSON(config.sendMessageApiUrl, sendMessageCommand);
        self.sendPrivateTextbox('');
    }

    function _callback(data) {
        ko.mapping.fromJS(data, {}, self);      
    }

    var pollingService = new chat.PollingService(config.ajaxService, config.pollApiUrl, config.name, _callback);
    pollingService.poll();

    setTimeout(function () { config.ajaxService.postJSON(config.getUsersApiUrl, { sender: config.name }) }, 100);

};