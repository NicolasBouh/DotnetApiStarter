

import { NgModule } from '@angular/core';
import {TuiButtonModule, TuiLinkModule} from "@taiga-ui/core";
import {TuiInputModule, TuiInputPasswordModule, TuiCheckboxLabeledModule} from "@taiga-ui/kit";

const COMPONENTS = [
  TuiButtonModule,
  TuiInputModule,
  TuiInputPasswordModule,
  TuiCheckboxLabeledModule,
  TuiLinkModule
];

@NgModule({
  imports: [
    ...COMPONENTS
  ],
  exports: [
    ...COMPONENTS
  ],
})
export class CustomTaigaModule {}
