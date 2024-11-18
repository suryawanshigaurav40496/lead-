import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contacts } from './contacts.model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private apiUrl = 'http://localhost:5104/api/Contacts'; // Your API URL

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contacts[]> {
    return this.http.get<Contacts[]>(this.apiUrl);
  }

  addContact(contact: Contacts): Observable<Contacts> {
    return this.http.post<Contacts>(this.apiUrl, contact);
  }
}
