import { Component, Input } from '@angular/core';
import { NgxFileDropEntry } from 'ngx-file-drop';
import { HttpClientService } from '../http-client.service';
import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AlertifyService, MessageType, Position } from '../../admin/alertify.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../ui/custom-toastr.service';
import { FileUploadDialogComponent, FileUploadDialogState } from 'src/app/dialogs/file-upload-dialog/file-upload-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogService } from '../dialog.service';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';

@Component({
  selector: 'app-file-uploat',
  templateUrl: './file-uploat.component.html',
  styleUrls: ['./file-uploat.component.scss']
})
export class FileUploatComponent {
   constructor(
    public dialog:MatDialog,
    private dialogService:DialogService,
    private httpClientService:HttpClientService ,
    private alertifyService:AlertifyService,
    private customToastrService:CustomToastrService,
    private spinner:NgxSpinnerService
    
    ){
 }


  public files: NgxFileDropEntry[];

   @Input()options:Partial<FileUploatOptions>;



  public SelectedFile(files: NgxFileDropEntry[]) {
    this.files = files; 
    
    
    const fileData:FormData=new FormData();
     for(const file of files)
     {
      (file.fileEntry as FileSystemFileEntry).file((_file:File)=>{
        fileData.append(_file.name,_file,file.relativePath);
      });
     }
 
this.dialogService.openDialog (
  {componentType:FileUploadDialogComponent,
    data:FileUploadDialogState.Yes,
    afterClosed:()=>{
      this.spinner.show(SpinnerType.BallAtom)
      this.httpClientService.post({
        controller:this.options.controller,
        action:this.options.action,
        queryString:this.options.querString,
       headers:new HttpHeaders({"responseType":"blob"})
       
   },fileData).subscribe(data=>{

 const message:string="Dosya başarılı şekilde yüklenmiştir";
 this.spinner.hide(SpinnerType.BallAtom)

 if(this.options.isAdminPage)
 {
   this.alertifyService.message(message,
     {
     dismissothers:true,
     messageType:MessageType.Success,
     position:Position.TopRight
     }
   )
 }
 else{
 this.customToastrService.message(message,"başarılı.",{
 messageType:ToastrMessageType.Success,
 position:ToastrPosition.TopRight
 })
 }
 
   },(errorResponse:HttpErrorResponse)=> {
     const message:string="Beklenmeyen Bir hata oluştu";
     this.spinner.hide(SpinnerType.BallAtom)

     if(this.options.isAdminPage)
     {
       this.alertifyService.message(message,
         {
         dismissothers:true,
         messageType:MessageType.Error,
         position:Position.TopRight 
     
         }
       )
     }
     else{
     this.customToastrService.message(message,"Başarısız!",{
     
     messageType:ToastrMessageType.Error,
     position:ToastrPosition.TopRight
     
     })
     }
   });
     }
  }
);
}


/*
  openDialog(afterClosed:any): void {
    const dialogRef = this.dialog.open(FileUploadDialogComponent, {
      
      data: FileUploadDialogState.Yes,
    });

    dialogRef.afterClosed().subscribe(result => {
     if(result==FileUploadDialogState.Yes) 
     afterClosed();
    
    });
  }
  */

 
}
export class FileUploatOptions{
  controller?:string;
  action?:string;
  querString:string;
  exlanation?:string;
  accept?:string;
  isAdminPage?:boolean=false;
}
