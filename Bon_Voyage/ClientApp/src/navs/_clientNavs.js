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
            name: 'Профіль',
            url: '/client/profile',
            icon: 'icon-user',
        },
        {
            name: 'Гарячі тури',
            url: '/client/hottravel',
            icon: 'icon-fire',
        },
        {
            name: 'Обрані тури',
            url: '/client/selectedtravel',
            icon: 'icon-star',
        },
        {
            name: 'Галерея',
            url: '/client/galery',
            icon: 'icon-grid',
        },
        {
            name: 'Мапа',
            url: '/client/map',
            icon: 'icon-map',
        },
        {
            name: 'Написати нам',
            url: '/client/message',
            icon: 'icon-envelope',
        }
    ]
};
