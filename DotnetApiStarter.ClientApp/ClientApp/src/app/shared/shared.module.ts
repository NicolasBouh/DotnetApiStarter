import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavMenuComponent} from "./layouts/nav-menu/nav-menu.component";
import {RouterModule} from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";
import {CustomTaigaModule} from "../custom-taiga.module";
import {TuiDialogModule} from "@taiga-ui/core";

const COMPONENTS = [
  NavMenuComponent
];

@NgModule({
  declarations: [...COMPONENTS],
  exports: [...COMPONENTS],
  imports: [
    CommonModule, CustomTaigaModule, RouterModule, ReactiveFormsModule, TuiDialogModule
  ],
})
export class SharedModule { }
