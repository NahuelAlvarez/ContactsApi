import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Contact } from '../models/contact';


@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  myAppUrl = 'http://localhost:61236/';
  myApiUrl = 'api/ContactsApi';
  list: Contact[];
  private updateForm = new BehaviorSubject<Contact>({} as any);

  constructor(private http: HttpClient) {
  
  }

  saveContact(contact: Contact): Observable<Contact>{
    return this.http.post<Contact>(this.myAppUrl+this.myApiUrl,contact)
  }

  getContacts() {
    this.http.get(this.myAppUrl + this.myApiUrl).toPromise()
      .then(data => {
        this.list = data as Contact[];
      });
  }

  deleteContact(id?: undefined) : Observable<Contact> {
    return this.http.delete<Contact>(this.myAppUrl + this.myApiUrl +"/"+ id);
  }

 
  updateContact(id: undefined, contact: Contact): Observable<Contact>{
    return this.http.put<Contact>(this.myAppUrl + this.myApiUrl + "/" + id, contact);
  }
  
  update(contact:any) {
    this.updateForm.next(contact);
  }

  getContact(): Observable<Contact>{
    return this.updateForm.asObservable();
  }
}
