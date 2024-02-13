import { AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, _MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component'; 
import { list_Animal } from 'src/app/contracts/list_animal';
import { SelectAnimalImageDialogComponent } from 'src/app/dialogs/select-animal-image-dialog/select-animal-image-dialog.component';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { DialogService } from 'src/app/services/common/dialog.service'; 
import { AnimalService } from 'src/app/services/common/models/animal.service';
import { FileService } from 'src/app/services/common/models/file.service';
declare var $:any;


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent extends BaseComponent implements OnInit  {
  
//   constructor(spinner:NgxSpinnerService, 
//     private applicantService:ApplicationService,
//     private alertifyService:AlertifyService,
//     private dialogService:DialogService,
//     private fileServide:FileService
//     )  
//   {
//     super(spinner)
//   }
//     ngAfterViewInit(): void { 

//     }

  
//    displayedColumns: string[] = ['applicantCode ','userName','description',`delete`];
//    dataSource:MatTableDataSource<list_Application>=null;
   
//    @ViewChild(MatPaginator)paginator:MatPaginator;


//      async getAnimal(){
//         this.Spannershow(SpinnerType.BallAtom);
//         const Allapplicant:{totalAnimalCount : number; animals:list_Application[] }=await this.
//         (this.paginator? this.paginator.pageIndex:0,this.paginator?this.paginator.pageSize:5,()=>this
//         .HideSpennar(SpinnerType.BallAtom),errorMessage=>this.alertifyService.message(errorMessage,{
//           dismissothers:true,
//           messageType:MessageType.Error,
//           position:Position.TopRight
//         }))
     
//         this.dataSource=new MatTableDataSource<list_Application>(Allapplicant.animals);
//         this.paginator.length=Allapplicant.totalAnimalCount;
 
//        }
   
//        addAnimalImage(id:string){
//         this.dialogService.openDialog({
//         componentType:SelectAnimalImageDialogComponent,
//         data:id,
//          options:{
//           width:"1400px" 
//          } 
//         });


//        }


//       async pageChanged(){
//         await this.getAnimal();
//        }
        
//       async ngOnInit() {
//       await this.getAnimal();
//       }

// }




constructor(spinner:NgxSpinnerService, 
  private animalService:AnimalService,
  private alertifyService:AlertifyService,
  private dialogService:DialogService,
  private fileServide:FileService
  )  
{
  super(spinner)
}
  ngAfterViewInit(): void { 

  }


 displayedColumns: string[] = ['name','age','gender',`type`,`vaccination`,`photos`,`edit`,`delete`];
 dataSource:MatTableDataSource<list_Animal>=null;
 
 @ViewChild(MatPaginator)paginator:MatPaginator;


   async getAnimal(){
      this.Spannershow(SpinnerType.BallAtom);
      const AllAnimal:{totalAnimalCount : number; animals:list_Animal[] }=await this.animalService.read
      (this.paginator? this.paginator.pageIndex:0,this.paginator?this.paginator.pageSize:5,()=>this
      .HideSpennar(SpinnerType.BallAtom),errorMessage=>this.alertifyService.message(errorMessage,{
        dismissothers:true,
        messageType:MessageType.Error,
        position:Position.TopRight
      }))
   
      this.dataSource=new MatTableDataSource<list_Animal>(AllAnimal.animals);
      this.paginator.length=AllAnimal.totalAnimalCount;

     }
 
     addAnimalImage(id:string){
      this.dialogService.openDialog({
      componentType:SelectAnimalImageDialogComponent,
      data:id,
       options:{
        width:"1400px"


        
       } 
      });


     }


    async pageChanged(){
      await this.getAnimal();
     }
      
    async ngOnInit() {
    await this.getAnimal();
    }

}
