import './App.css';
import 'antd/dist/antd.css';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Books from './Pages/Books/Books';
import React, { useEffect } from 'react';
import * as actions from './store/actions/index'
import { connect } from 'react-redux'
import SingleBook from './Pages/SingleBook/SingleBook';
import ModalCustom from './components/Modal/ModalCustom';
import Navigation from './components/Navigation/Navigation';
import Login from './Pages/Login/Login';
import Register from './Pages/Register/Register'

function App({ onFetchCategories, onAuthCheckState }) {

  useEffect(() => {
    onFetchCategories();
    onAuthCheckState()
  }, [onFetchCategories, onAuthCheckState])


  return (
    <BrowserRouter>
      <Navigation/>
      <Switch>
        <Route path='/' component={Books} exact/>
        <Route path='/book/:id' component={SingleBook} exact/>
        <Route path='/login' component={Login} />
        <Route path='/register' component={Register} />
        <Route path='/:category' component={Books} exact />
      </Switch>
      <ModalCustom/>
    </BrowserRouter>
  );
}

const mapDispatchToProp = dispatch => {
  return {
    onFetchCategories: () => dispatch(actions.fetchCategories()),
    onAuthCheckState: () => dispatch(actions.authCheckState())
  }
}

export default connect(null, mapDispatchToProp)(App);
