import { Component, OnInit } from '@angular/core';
import { AuthModule } from '../auth.module';
import {NgForm} from '@angular/forms';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  loginData = {
    email : '',
    password : '',
    isTermsAccepted: false
  }
  constructor() { }
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    
  }
  onLogin(form : NgForm){
    if(form.valid){
      console.log(this.loginData);
    }
}
}
