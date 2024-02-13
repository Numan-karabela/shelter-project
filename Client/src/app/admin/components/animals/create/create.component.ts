 import { Component,OnInit, Output } from '@angular/core';
 import { EventEmitter } from '@angular/core';

import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_Animal } from 'src/app/contracts/create_animal';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { FileUploatOptions } from 'src/app/services/common/file-uploat/file-uploat.component';
import { AnimalService } from 'src/app/services/common/models/animal.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent extends BaseComponent implements OnInit {

constructor(spiner:NgxSpinnerService, private animalService:AnimalService ,private alertify:AlertifyService){

  super(spiner)
}

ngOnInit(): void {
}
@Output() createdAnimal:EventEmitter<Create_Animal>=new EventEmitter();

   @Output() fileUploadOptions:Partial<FileUploatOptions>={

    action:"upload",
    controller:"product",
    exlanation:"Resimleri Seçiniz veya sürükleyin",
    isAdminPage:true,
    accept:".png, .jpg, .jpeg, .json"
 
   };



   create(vaccination:HTMLInputElement,gender:HTMLInputElement,age:HTMLInputElement,type:HTMLInputElement,name:HTMLInputElement)
   {
    this.HideSpennar(SpinnerType.BallAtom)
      const  create_animal:Create_Animal=new Create_Animal();
        create_animal.name=name.value;
        create_animal.gender=gender.value;
        create_animal.type=type.value;
        create_animal.age=parseInt(age.value);
        create_animal.vaccination=vaccination.value;
        if(!name.value){
          this.alertify.message("Lütfen isim değerini 0-10 karakter arasında değer giriniz",{
            dismissothers:true,
            messageType:MessageType.Error,
            position:Position.TopRight
          });
          return;
        }
        if(!gender.value){
          this.alertify.message("Lütfen isim değerini 0-10 karakter arasında değer giriniz",{
            dismissothers:true,
            messageType:MessageType.Error,
            position:Position.TopRight
          });
          return;
        }
        if(!type.value){
          this.alertify.message("Lütfen cins değerini 0-10 karakter arasında değer giriniz",{
            dismissothers:true,
            messageType:MessageType.Error,
            position:Position.TopRight
          });
          return;
        }
        if(parseInt(age.value)<0){
          this.alertify.message("Lütfen yaş değerini 0-15 arasında değer giriniz",{
            dismissothers:true,
            messageType:MessageType.Error,
            position:Position.TopRight
          });
          return;
        }
        if(!vaccination.value){
          this.alertify.message("Aşı durumu boş girilemez",{
            dismissothers:true,
            messageType:MessageType.Error,
            position:Position.TopRight
          });
          return;
        }

     this.animalService.create(create_animal,()=>{
     this.HideSpennar(SpinnerType.BallAtom);
     this.alertify.message("Başarıyla Eklendi.",{
      dismissothers:true,
      messageType:MessageType.Success,
      position: Position.TopRight
       
     },);
    this.createdAnimal.emit(create_animal);
  }, 
   errorMessage=> {
  this.alertify.message(errorMessage,
    {
        dismissothers:true,
        messageType:MessageType.Error,
        position:Position.TopRight
    });
   }); 
    
  };
  
  
   }
