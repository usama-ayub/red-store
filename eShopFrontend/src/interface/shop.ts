export interface ICShop {
  name: string
  longtitude: number
  latitude: number
  fileInfo: ICShopImage[]
  address: string
  contactNumber: string
  website: string
}

export interface ICShopImage {
  main: boolean
  file: File
  url:string
}