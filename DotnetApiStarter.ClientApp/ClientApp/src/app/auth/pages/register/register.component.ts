import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    console.warn(this.registerForm.value);
  }

}
