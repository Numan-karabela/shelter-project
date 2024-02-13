import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';

@Component({
  selector: 'app-animals',
  templateUrl: './animals.component.html',
  styleUrls: ['./animals.component.scss']
})
export class AnimalsComponent extends BaseComponent {

  constructor( spinner:NgxSpinnerService){
    super(spinner)
        
      }
    
    
    ngOnInit(): void {
      // this.Spannershow(SpinnerType.BallAtom);
    
    }
}
