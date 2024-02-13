import { Component,OnInit} from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { HubUrls } from 'src/app/constants/hub-urls';
import { ReceiveFunctions } from 'src/app/constants/receive-functions';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';  
import { SignalRService } from 'src/app/services/common/signalr.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends BaseComponent  implements OnInit {
  constructor(private alertify:AlertifyService ,spinner:NgxSpinnerService,
    private signalRService:SignalRService){
    super(spinner)
        signalRService.start(HubUrls.AnimalHub)
        signalRService.start(HubUrls.ApplicationHub) 
      }
    
    
    ngOnInit(): void { 
       this.signalRService.on(ReceiveFunctions.AnimalAddedMessageReceiveFunctions,message=>{
        this.alertify.message(message,{ 
          messageType:MessageType.Warning,
          position:Position.TopRight
        })        
     });
     
     this.signalRService.on(ReceiveFunctions.ApplicationAddedMessageReceiveFunctions,message=>{
      this.alertify.message(message,{  
        messageType:MessageType.Warning,
        position:Position.TopCenter
      }) 
   });
    }
     
     
m()
{
  this.alertify.message("Merhaba",{
    messageType:MessageType.Success,
  delay:1.5, 
  position:Position.BottomLeft,
  dismissothers:true
}) 
} 


d()
{
  this.alertify.dismiss()
}
 
 } 
