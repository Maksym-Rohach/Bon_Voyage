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
      name: 'Statistic',
      url: '/admin/statistic',
      icon: 'icon-puzzle',
      children: [
        {
          name: 'Breadcrumbs',
          url: '/admin/statistic',
          icon: 'icon-puzzle',
        },
        {
          name: 'Cards',
          url: '/base/cards',
          icon: 'icon-puzzle',
        },
        {
          name: 'Carousels',
          url: '/base/carousels',
          icon: 'icon-puzzle',
        }
      ]
    },       
    {
      name: 'ManagerControl',
      url: '/admin/manager/control',
      icon: 'icon-cursor',
    },
    {
      name: 'AirportControl',
      url: '/admin/airport/control',
      icon: 'icon-cursor',
    }
  ]
};
