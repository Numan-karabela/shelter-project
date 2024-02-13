import { Component, Inject, OnInit, Output } from '@angular/core';
import { BaseDialog } from '../base/base-dialog';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DeleteDialogComponent, DeleteState } from '../delete-dialog/delete-dialog.component';
import { FileUploatOptions } from 'src/app/services/common/file-uploat/file-uploat.component';
import { AnimalService } from 'src/app/services/common/models/animal.service';
import { list_Animal_image } from 'src/app/contracts/list_animal_image';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';
import { every } from 'rxjs';
import { DialogService } from 'src/app/services/common/dialog.service';
declare var $:any


@Component({
  selector: 'app-select-animal-image-dialog',
  templateUrl: './select-animal-image-dialog.component.html',
  styleUrls: ['./select-animal-image-dialog.component.scss']
})
export class SelectAnimalImageDialogComponent extends BaseDialog<SelectAnimalImageDialogComponent>  implements OnInit{


constructor(dialogRef:MatDialogRef<SelectAnimalImageDialogComponent>,
  @Inject(MAT_DIALOG_DATA) public data:SelectAnimalImageState | string, 
  private animalService:AnimalService,
  private spinner:NgxSpinnerService,
  private dialogService:DialogService,
  ){
  super(dialogRef)
 }

 
 @Output() options:Partial<FileUploatOptions>={
  accept:".png,.jpg,.jpeg,.gif",
  action:"Upload",
  controller:"Product",
  exlanation:"Resimleri seçiniz...",
  isAdminPage:true,
  querString:`id=${this.data}`
};

images:list_Animal_image[];
 
async ngOnInit() {
  this.spinner.show(SpinnerType.BallAtom);
  this.images=await this.animalService.readImage(this.data as string,()=>this.spinner.hide(SpinnerType.BallAtom));
}

async deleteImage(imageId:string ,event:any){

this.dialogService.openDialog({
componentType:DeleteDialogComponent,
data:DeleteState.Yes,
afterClosed:async ()=>{
this.spinner.show(SpinnerType.BallAtom)
await this.animalService.deleteImage(this.data as string,imageId,()=>{
  this.spinner.hide(SpinnerType.BallAtom);
var card=$(event.srcElement).parent().parent()
card.fadeOut(500);

       });
       }
    })    
 }


 showCase(imageId:string){ 
this.spinner.show(SpinnerType.BallAtom); 

this.animalService.chanceShowcaseImage(imageId,this.data as string,()=>{
this.spinner.hide(SpinnerType.BallAtom);


});

 
 }
}


export enum SelectAnimalImageState{

  Close
}