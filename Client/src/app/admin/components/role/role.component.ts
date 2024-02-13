import { Component, OnInit, ViewChild } from '@angular/core';  
import { ListComponent } from '../role/list/list.component';
import { BaseComponent } from 'src/app/base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent extends BaseComponent implements OnInit {

  constructor( spinner:NgxSpinnerService,private httpClientService:HttpClientService){
    super(spinner)
        
      }
  ngOnInit(): void { 
  }



@ViewChild(ListComponent)listComponents:ListComponent;
createdRole(createRole:string){
  this.listComponents.getRoles();
}


}
