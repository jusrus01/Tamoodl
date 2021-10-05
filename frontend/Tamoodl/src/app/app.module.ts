import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AuthGuard } from './auth.guard';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { TeachersComponent } from './teachers/teachers.component';
import { AdminsComponent } from './admins/admins.component';
import { StudentsComponent } from './students/students.component';
import { ForumsComponent } from './forums/forums.component';

export const routes : Routes = [
    { path: '', component: HomeComponent, data: { title: "Home" }, canActivate: [AuthGuard] },
    // { path: "**", redirectTo: "" },
    { path: "login", component: LoginComponent, data: { title: "Login" } }
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    TeachersComponent,
    AdminsComponent,
    StudentsComponent,
    ForumsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
