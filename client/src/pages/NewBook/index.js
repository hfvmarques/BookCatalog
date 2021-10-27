import React, { useState } from 'react'
import { Link, useHistory } from 'react-router-dom'
import { FiArrowLeft } from 'react-icons/fi'
import './styles.css'
import api from '../../services/api'
import logoImage from '../../assets/logo.svg'

export default function NewBook() {

  const [title, setTitle] = useState('');
  const [author, setAuthor] = useState('');
  const [publishingCompany, setPublishingCompany] = useState('');
  const [publicationYear, setPublicationYear] = useState('');
  const [edition, setEdition] = useState('');

  const history = useHistory()

  async function createNewBook(e) {
    e.preventDefault()

    const data = {
      title,
      author,
      publishingCompany,
      publicationYear,
      edition
    }

    try {
      await api.post('/books', data)
    } catch (err) {
      alert('Erro ao gravar o livro. Tente novamente')
    }
    history.push('/')
  }

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

        <form onSubmit={createNewBook}>
          <input
            placeholder="Title"
            value={title}
            onChange={e => setTitle(e.target.value)}
          />
          <input
            placeholder="Author"
            value={author}
            onChange={e => setAuthor(e.target.value)}
          />
          <input
            placeholder="PublishingCompany"
            value={publishingCompany}
            onChange={e => setPublishingCompany(e.target.value)}
          />
          <input
            placeholder="PublicationYear"
            value={publicationYear}
            onChange={e => setPublicationYear(e.target.value)}
          />
          <input
            placeholder="Edition"
            value={edition}
            onChange={e => setEdition(e.target.value)}
          />
          <button className="button" type="submit">Adicionar</button>
        </form>
      </div>
    </div>
  )
}