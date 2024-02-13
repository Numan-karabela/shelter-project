import { Component ,OnInit} from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';

@Component({
  selector: 'app-applicants',
  templateUrl: './applicants.component.html',
  styleUrls: ['./applicants.component.scss']
})
export class ApplicantsComponent extends BaseComponent implements  OnInit {


  constructor(spinner:NgxSpinnerService){
    super(spinner)
        
      }
    
    
    ngOnInit(): void { 
    
    }
     
     } 