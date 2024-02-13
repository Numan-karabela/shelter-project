import { Component, Inject, OnDestroy, Output } from '@angular/core';   
import { BaseDialog } from '../base/base-dialog';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatDialog} from '@angular/material/dialog'; 
import { MatButton } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-authorize-menu-dialog',
  templateUrl: './authorize-menu-dialog.component.html',
  styleUrls: ['./authorize-menu-dialog.component.scss']
})

export class AuthorizeMenuDialogComponen extends BaseDialog<AuthorizeMenuDialogComponen>{
constructor(dialogRef:MatDialogRef<AuthorizeMenuDialogComponen>,
 @Inject(MAT_DIALOG_DATA) public data:any){
super(dialogRef)
}
}


export enum authorizeMenuState{
 Yes,
 No
}