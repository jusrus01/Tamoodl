import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService, 
    private formBuilder: FormBuilder) { }

    public loginForm = this.formBuilder.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
    });

    ngOnInit(): void {
      
    }
    
    public login() : void {
        if(this.loginForm.valid) {
            let values = this.loginForm.value;
            console.log(values);
            this.authService.login(values).subscribe(x => console.log(x));
        } else {
            // show error message
        }
    }
}
