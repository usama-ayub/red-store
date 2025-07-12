import { defineStore } from 'pinia'

interface MenuLink {
  name: string
  href: string
  active: boolean
  show: boolean
  icon: string
  isRouting:boolean
}

export const useAppStore = defineStore('app', {
  state: (): { menuLinks: MenuLink[] } => ({
    menuLinks: [
      { name: 'Home', href: '/', active: true,show:true,icon:'',isRouting:true },
      { name: 'Products', href: '/products', active: false,show:true,icon:'',isRouting:true  },
      { name: 'Shops', href: 'shops', active: false,show:true,icon:'',isRouting:true},
      { name: 'Account', href: '/account', active: false,show:true,icon:'',isRouting:true  },
      { name: 'My Account', href: '', active: false,show:false,icon:'',isRouting:false  },
      { name: 'About Us', href: '', active: false,show:true,icon:'',isRouting:true  },
    ]
  }),

  actions: {
    setActive(index: number) {
      this.menuLinks.forEach(link => (link.active = false))
      if (this.menuLinks[index]) {
        this.menuLinks[index].active = true
      }
    },
    setAuthantication(){
      this.menuLinks[3].show = false;
      this.menuLinks[3].active = false;

      this.menuLinks[4].show = true;
      this.menuLinks[4].active = false;
    }
  }
})