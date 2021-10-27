import React from 'react'
import { Link } from 'react-router-dom'
import { FiArrowLeft } from 'react-icons/fi'
import './styles.css'
import logoImage from '../../assets/logo.svg'

export default function NewBook() {
  return (
    <div className="new-book-container">
      <div className="content">
        <section className="form">
          <img src={logoImage} alt="Catálogo de livros" />
          <h1>Adicionar novo livro</h1>
          <p>Digite as informações do livro e clique em 'Adicionar'</p>
          <Link className="back-link" to="/" exact>
            <FiArrowLeft size={16} color="#251fc5" />
            Página Inicial
          </Link>
        </section>
        <form>
          <input placeholder="Title" />
          <input placeholder="Author" />
          <input placeholder="PublishingCompany" />
          <input placeholder="PublicationYear" />
          <input placeholder="Edition" />
          <button className="button" type="submit">Adicionar</button>
        </form>
      </div>
    </div>
  )
}