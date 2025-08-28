import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from '../auth/auth.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { Routes } from '@angular/router';

//auth module components routing
const routes: Routes = [
{
  path : 'login', component : LoginComponent
},
{
  path : 'register', component : RegistrationComponent
}
]
@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    NgModule,
    FormsModule
  ]
})
export class AuthModule { }
