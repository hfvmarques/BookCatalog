import React from "react"
import { BrowserRouter, Route, Switch } from 'react-router-dom'

import BookCatalog from './pages/BookCatalog'
import Book from "./pages/Book"

export default function Routes() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" exact component={BookCatalog} />
        <Route path="/Book/:bookId" component={Book} />
        {/* <Route path="/OutraPagina" component={OutraPagina} /> */}
      </Switch>
    </BrowserRouter>
  )
}