import { Injectable } from '@angular/core';
declare var alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }


 // message(message:String, messageType:MessageType=MessageType.Success, position:Position, delay:number=5, dismissothers:boolean=false)
  message(message:String,options:Partial<AlertifyOptions>)
 
 
 {
    alertify.set('notifier','delay',options.delay)
    alertify.set('notifier','position',options.position)

    const msj=alertify[options.messageType](message);
    if(options.dismissothers)
    msj.dismissothers(); 
  }
  
  dismiss() 
  {
alertify.dismissAll();
}

  }

  export class AlertifyOptions{
    messageType:MessageType=MessageType.Message;
    position:Position=Position.TopRight;
    delay:number=3;
    dismissothers:boolean=false;
  }

export enum MessageType{
  Error="error",
  Message="message",
  Notify="notifu",
  Success="success",
  Warning="warning",
}
export enum Position{
  TopCenter="top-center",
  TopRight="top-right",
  TopLeft="top-left",
  BottomRight="bottom-right",
  BottomCenter="bottom-center",
  BottomLeft="bottom-left"
}