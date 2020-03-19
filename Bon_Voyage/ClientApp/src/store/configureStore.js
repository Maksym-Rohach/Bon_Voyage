import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { connectRouter, routerMiddleware } from 'connected-react-router';
// import { createBrowserHistory } from 'history';
import createHistory from 'history/createHashHistory';
///reducers
import {personsChartReducer} from '../views/adminViews/PersonsChart/reducer';
import {commentsChartReducer} from '../views/adminViews/CommentsChart/reducer';
import {loginReducer} from '../views/othersViews/LoginPage/reducer';

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
export const history = createHistory({ basename: baseUrl });

export default function configureStore(history, initialState) {
  const reducers = {
    login: loginReducer,
    persons: personsChartReducer,
    comments: commentsChartReducer
  };

  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }



  const rootReducer = combineReducers({
    ...reducers,
    router: connectRouter(history)
  });

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );
}
