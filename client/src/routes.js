import React from "react"
import { BrowserRouter, Route, Switch } from 'react-router-dom'

import BookCatalog from './pages/BookCatalog'
import NewBook from "./pages/NewBook"

export default function Routes() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" exact component={BookCatalog} />
        <Route path="/NewBook/:bookId" component={NewBook} />
        {/* <Route path="/OutraPagina" component={OutraPagina} /> */}
      </Switch>
    </BrowserRouter>
  )
}