export default {
  items: [
    {
      title: true,
      name: 'Меню',
      wrapper: {            // optional wrapper object
        element: '',        // required valid HTML5 element tag
        attributes: {}        // optional valid JS object with JS API naming ex: { className: "my-class", style: { fontFamily: "Verdana" }, id: "my-id"}
      },
      class: ''             // optional class names space delimited list for title item ex: "text-center"
    },  
    {
      name: 'Керування користувачами',
      icon: 'icon-user',
      children: [
        {
          name: 'Менеджери',
          url: '/admin/manager/control',
          icon: 'icon-emotsmile',
        },
        {
          name: 'Клієнти',
          url: '/admin/client/control',
          icon: 'icon-people',
        }
      ]
    },    
    {
      name: 'Керування даними',
      icon: 'icon-settings',
      children: [
        {
          name: 'Керування готелями',
          url: '/admin/hotel/control',
          icon: 'icon-home',
        },
        {
          name: 'Керування містами',
          url: '/admin/city/control',
          icon: 'icon-directions',
        },
        {
          name: 'Керування аеропортами',
          url: '/admin/airport/control',
          icon: 'icon-plane',
        },
        {
          name: 'Керування країнами',
          url: '/admin/country/control',
          icon: 'icon-map',
        }
      ]
    },         
    {
      name: 'Статистика',
      icon: 'icon-chart',
      children: [
        {
          name: 'Statistic',
          url: '/admin/statistic',
          icon: 'icon-emotsmile',
        },
        {
          name: 'Statistic',
          url: '/base/cards',
          icon: 'icon-people',
        }
      ]
    },
    // {
    //   name: '$HOTEL PHOTOS SEEDER',
    //   url: '/admin/seeder/hotelPhotos',
    //   icon: 'icon-user',
    // }, 
  ]
};
