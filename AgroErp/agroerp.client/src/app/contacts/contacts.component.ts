import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from '../contact.service';
import { Contacts } from '../contacts.model';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactComponent implements OnInit {
  contacts: Contacts[] = [];
  contactForm: FormGroup;
  showForm = false;

  constructor(private contactService: ContactService, private fb: FormBuilder) {
    
    this.contactForm = this.fb.group({
      contactOwner: [null],
      firstName: [null, Validators.required],
      middleName: [null],
      lastName: [null, Validators.required],
      dateOfBirth: [null],
      email: [null, [Validators.required, Validators.email]],
      phoneNo: [null],
      currentAddress: [null],
      permanentAddress: [null],
      emailOptOut: [false],
      leadSource: [null],
      description: [null]
    });
  }

  ngOnInit(): void {
    this.getContacts();
  }

  
  getContacts(): void {
    this.contactService.getContacts().subscribe((data: Contacts[]) => {
      this.contacts = data;
    });
  }

  toggleForm() {
    this.showForm = !this.showForm;
  }

  
  addContact(): void {
    if (this.contactForm.valid) {
      console.log('Form Data:', this.contactForm.value);
      this.contactService.addContact(this.contactForm.value).subscribe((newContact: Contacts) => {
        this.contacts.push(newContact);
        this.contactForm.reset(); 
      });
    }
  }
}
