import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_Animal } from 'src/app/contracts/create_animal';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { FileUploatOptions } from 'src/app/services/common/file-uploat/file-uploat.component';
import { AnimalService } from 'src/app/services/common/models/animal.service';
import { RoleService } from 'src/app/services/common/models/role.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent extends BaseComponent implements OnInit{
  constructor(
     spiner:NgxSpinnerService,
     private roleService:RoleService ,
     private alertify:AlertifyService
     
     ){

    super(spiner)
  }
  
  ngOnInit(): void {
  }
  @Output() createdRole:EventEmitter<string>=new EventEmitter();
   
     create(name:HTMLInputElement) {
      this.Spannershow(SpinnerType.BallAtom);
      
      
       this.roleService.create(name.value,()=>{
       this.HideSpennar(SpinnerType.BallAtom);
       this.alertify.message("Role Eklendi.",{
        dismissothers:true,
        messageType:MessageType.Success,
        position: Position.TopRight 
       });
      this.createdRole.emit(name.value);
    },errorMessage=> {
    this.alertify.message(errorMessage,
      {
          dismissothers:true,
          messageType:MessageType.Error,
          position:Position.TopRight
      }); 
     }); 
    } 
   } 
  