export interface IProduct {
  id: string
  name: string
  price: number
  tags: string[]
  images: IProductImage[]
  categoryId: string
  categoryName: string
  subCategoryId: string
  subCategoryName: string
  shopId: string
  shopName: string
  createdBy: string
  userName: string
  isHotItem: boolean
}

export interface IProductImage {
  main: boolean
  url: string
}