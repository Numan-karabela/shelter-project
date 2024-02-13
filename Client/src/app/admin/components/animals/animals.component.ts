 import { Component,OnInit, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_Animal } from 'src/app/contracts/create_animal';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ListComponent } from './list/list.component';

@Component({
  selector: 'app-animals',
  templateUrl: './animals.component.html',
  styleUrls: ['./animals.component.scss']
})
export class AnimalsComponent extends BaseComponent implements OnInit {

  constructor( spinner:NgxSpinnerService, private httpClientService:HttpClientService){
    super(spinner)
        
      } 
    ngOnInit(): void { 
      } 
 
    @ViewChild(ListComponent)listComponents:ListComponent;
    createdAnimal(createdAnimal:Create_Animal){
   this.listComponents.getAnimal();


     }
      }
    
  
      