const firebase = require("nativescript-plugin-firebase")
const appSettings=require('application-settings')

export default class FirebaseConfig{
    constructor(){

    }
    init() {
        firebase.init({
            onMessageReceivedCallback:function(message){
                console.log(message.body);
            },
           onPushTokenReceivedCallback:function(token){
             console.log(token);
             appSettings.setString("firebaseToken",token)
           }
        }).then(() => {

        }).catch(() => {

        })
    }
}