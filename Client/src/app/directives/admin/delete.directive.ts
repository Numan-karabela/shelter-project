import { HttpErrorResponse } from '@angular/common/http';
import { Directive, ElementRef,  HostListener, Input, Output, Renderer2 } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { DeleteDialogComponent, DeleteState } from 'src/app/dialogs/delete-dialog/delete-dialog.component';
import { MessageType, Position } from 'src/app/services/admin/alertify.service';
import { DialogService } from 'src/app/services/common/dialog.service';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { AnimalService } from 'src/app/services/common/models/animal.service';
declare var $:any;


@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective  {
  AlertifyService: any;


  
  constructor(
    public dialog:MatDialog,
    private element:ElementRef,
    private _renderer:Renderer2, 
    private httpClientService:HttpClientService ,
    private spinner :NgxSpinnerService,
    private dialogService:DialogService
 
    )
     {  

      const img= _renderer.createElement("img");
      img.setAttribute("src","../../../assets/delete.png");
      img.setAttribute("style","cursor:pointer");
      img.width=25;
      img.height=25;
      _renderer.appendChild(element.nativeElement,img)
}

   @Input() id :string;  
   @Input() controller:string;
  @Output() callback:EventEmitter <any>=new EventEmitter();       
  


 @HostListener("click")
  async onclick(){  
    this.dialogService.openDialog({
componentType:DeleteDialogComponent,
data:DeleteDialogComponent ,


afterClosed:async()=>{
  this.spinner.show(SpinnerType.BallAtom);
const td:HTMLTableCellElement=this.element.nativeElement;
 this.httpClientService.delete({
  controller:this.controller,


 },this.id).subscribe(data=>{
  
$(td.parentElement).animate({
  opacity:0,
   left:"+=50",
   height:"toogle"
},700,()=>{
  this.callback.emit();
  this.AlertifyService.message("Silme işlemi başarılı",{
    dismissOthers:true,
    messageType:MessageType.Success,
    position:Position.TopRight
  })
});
},(errorRecponce:HttpErrorResponse)=>{
this.spinner.hide(SpinnerType.BallAtom);
  this.AlertifyService.message("Başarısız",{
  dismissOthers:true,
  messageType:MessageType.Success,
  position:Position.TopRight
})
});
}
      
    });
  }


  /*
  openDialog(afterClosed:any): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      data: DeleteState.Yes,
    });

    dialogRef.afterClosed().subscribe(result => {
     if(result==DeleteState.Yes) 
     afterClosed();   
    });
  }
*/
  }
 
