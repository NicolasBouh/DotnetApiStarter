import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {TuiNotificationsService} from "@taiga-ui/core";
import {NotificationService} from "../../../core/services/notification.service";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  validationErrors: any;

  constructor(private fb : FormBuilder, private notificationService: NotificationService,
              private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required,
        Validators.minLength(4), Validators.maxLength(25)]],
      rememberMe: [false],
    })
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe(_response => {
      this.notificationService.showSuccess("User logged with success");
      this.router.navigateByUrl('/');
    }, error => {
      this.validationErrors = error;
    })
  }

}
