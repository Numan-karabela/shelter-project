import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { list_Role } from 'src/app/contracts/role/list_Role';
import { SelectAnimalImageDialogComponent } from 'src/app/dialogs/select-animal-image-dialog/select-animal-image-dialog.component';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { DialogService } from 'src/app/services/common/dialog.service';
import { AnimalService } from 'src/app/services/common/models/animal.service';
import { FileService } from 'src/app/services/common/models/file.service';
import { RoleService } from 'src/app/services/common/models/role.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent extends BaseComponent implements OnInit {
  animalService: any;

  constructor(spinner:NgxSpinnerService, 
    private roleService:RoleService,
    private alertifyService:AlertifyService,
    private dialogService:DialogService,
    private fileServide:FileService
    )  
  {
    super(spinner)
  }
    ngAfterViewInit(): void { 

    }

  
   displayedColumns: string[] = ['name',`edit`,`delete`];
   dataSource:MatTableDataSource<list_Role>=null;
   
   @ViewChild(MatPaginator)paginator:MatPaginator;


     async getRoles(){
        this.Spannershow(SpinnerType.BallAtom);
        const allRoles:{datas:list_Role[]}  =await this.roleService.getRoles(this.paginator? 
        this.paginator.pageIndex:0,this.paginator?this.paginator.pageSize:5,()=>
        this.HideSpennar(SpinnerType.BallAtom),(errorMessage:any)=>this.alertifyService.message
        (errorMessage,{
          dismissothers:true, 
          messageType:MessageType.Error,
          position:Position.TopRight
        }))
     
        this.dataSource=new MatTableDataSource<list_Role>(allRoles.datas);
        this.paginator.length=allRoles.datas.length;
 
       }
     
      async pageChanged(){
        await this.getRoles();
       }
        
      async ngOnInit() {
      await this.getRoles();
      }
}
