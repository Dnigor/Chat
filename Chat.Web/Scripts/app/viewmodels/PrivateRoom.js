var chat = chat || {};

chat.PrivateRoom = function (name) {
    var self = this;

    self.name = name;
    self.content = ko.observable();
    self.unreadMessagesCount = ko.observable(0);

}