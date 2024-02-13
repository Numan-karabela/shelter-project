import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';

@Component({
  selector: 'app-donation',
  templateUrl: './donation.component.html',
  styleUrls: ['./donation.component.scss']
})
export class DonationComponent extends BaseComponent {

  constructor( spinner:NgxSpinnerService){
    super(spinner)
        
      }
    
    
    ngOnInit(): void {
      // this.Spannershow(SpinnerType.BallAtom);
    
    }
  }