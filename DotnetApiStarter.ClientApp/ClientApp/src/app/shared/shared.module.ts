import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavMenuComponent} from "./nav-menu/nav-menu.component";
import {RouterModule} from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";
import {CustomTaigaModule} from "../custom-taiga.module";

const COMPONENTS = [
  NavMenuComponent
];

@NgModule({
  declarations: [...COMPONENTS],
  exports: [...COMPONENTS],
  imports: [
    CommonModule, CustomTaigaModule, RouterModule, ReactiveFormsModule
  ]
})
export class SharedModule { }
