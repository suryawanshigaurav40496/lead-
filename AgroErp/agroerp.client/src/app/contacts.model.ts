

export interface Contacts {
  id: number;
  contactOwner: string | null;
  firstName: string | null;
  middleName: string | null;
  lastName: string | null;
  dateOfBirth: Date | null;
  email: string;
  phoneNo: string | null;
  currentAddress: string | null;
  permanentAddress: string | null;
  emailOptOut: boolean;
  leadSource: string | null;
  createdAt: Date;
  modifiedAt: Date;
  description: string | null;
}
