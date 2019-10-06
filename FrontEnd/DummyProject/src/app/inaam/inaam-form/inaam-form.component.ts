import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServerInfo } from '../../classes/ServerInfo';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'inaam-form',
  templateUrl: './inaam-form.component.html',
  styleUrls: ['./inaam-form.component.scss']
})
export class InaamFormComponent implements OnInit {

  @Input()
  getSchemaAndOptionsUrl = "";
  @Input()
  isEditing: boolean = false;

  @Input()
  insertUrl: string = '';

  @Input()
  editUrl: string = '';

  @Input()
  updateUrl: string = '';

  @Output()
  submittedSuccessfully: EventEmitter<any> = new EventEmitter();

  schema: Array<any>;
  options: Object;
  mainForm: FormGroup;
  isLoading: boolean = false;
  

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  async ngOnInit() {
    this.isLoading = true;
    await this.http.get(this.getSchemaAndOptionsUrl).toPromise()
      .then(data => {
        this.schema = <Array<any>>data['schema'];
        this.options = data['options'];
        this.initMainFormBySchema();
      });

    if(this.isEditing) {
      await this.http.get(this.editUrl).toPromise()
        .then(data => {
          this.mainForm.setValue(data);
        });
    }

    this.isLoading = false;
  }

  initMainFormBySchema() {
    this.mainForm = this.fb.group([]);

    this.schema.forEach(schemaItem => {
      let validators = this.generateValidatorsArray(schemaItem);
      this.generateValidatorsArray(schemaItem);
      this.mainForm.addControl(schemaItem.name, this.fb.control('', validators))
    });
  }


  private generateValidatorsArray(schemaItem: any) {
    let validators: any[] = [];
    if (schemaItem.validations && schemaItem.validations.length > 0) {
      schemaItem.validations.forEach(validation => {
        if (validation == "required") {
          validators.push(Validators.required);
        }
        if (validation == "email") {
          validators.push(Validators.email);
        }
        if (validation.indexOf("minLength:") > -1) {
          let colonIndex = validation.indexOf(":");
          validators.push(Validators.minLength( +validation.substring(colonIndex + 1)));
        }
        if (validation.indexOf("maxLength:") > -1) {
          let colonIndex = validation.indexOf(":");
          validators.push(Validators.maxLength( +validation.substring(colonIndex + 1)));
        }
        if (validation.indexOf("min:") > -1) {
          let colonIndex = validation.indexOf(":");
          validators.push(Validators.min( +validation.substring(colonIndex + 1)));
        }
        if (validation.indexOf("max:") > -1) {
          let colonIndex = validation.indexOf(":");
          validators.push(Validators.max( +validation.substring(colonIndex + 1)));
        }
      });
    }
    return validators;
  }

  onSubmit() {
    let observable = null;
    if(!this.isEditing) {
      observable = this.http.post(this.insertUrl, this.mainForm.value);
    } else {
      observable = this.http.put(this.updateUrl, this.mainForm.value);
    }
    this.isLoading = true;
    observable.subscribe(data => {
      alert(data.message);
      this.submittedSuccessfully.emit(null);
    }, 
    error => {
      console.log(error);
      alert("Error occurred");
    }).add(() => {
      this.isLoading = false;
    })
  }
}
