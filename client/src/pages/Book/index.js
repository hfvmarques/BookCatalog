import React, { useEffect, useState } from 'react'
import { Link, useHistory, useParams } from 'react-router-dom'
import { FiArrowLeft } from 'react-icons/fi'
import './styles.css'
import api from '../../services/api'
import logoImage from '../../assets/logo.svg'

export default function Book() {

  const { bookId } = useParams()
  const [id, setId] = useState(null)
  const [title, setTitle] = useState('')
  const [author, setAuthor] = useState('')
  const [publishingCompany, setPublishingCompany] = useState('')
  const [publicationYear, setPublicationYear] = useState('')
  const [edition, setEdition] = useState('')
  const [subject, setSubject] = useState('')


  const history = useHistory()

  useEffect(() => {
    if (bookId === '0') return

    loadBook()
  }, bookId)

  async function loadBook() {
    try {
      const response = await api.get(`/books/${bookId}`)

      setId(response.data.id)
      setTitle(response.data.title)
      setAuthor(response.data.author)
      setPublishingCompany(response.data.publishingCompany)
      setPublicationYear(response.data.publicationYear)
      setEdition(response.data.edition)
      setSubject(response.data.subject)

    } catch (err) {
      alert('Erro ao recuperar livro a ser editado. Tente novamente')
      history.push('/')
    }
  }

  async function saveOrUpdate(e) {
    e.preventDefault()

    const data = {
      title,
      author,
      publishingCompany,
      publicationYear,
      edition,
      subject
    }

    try {
      if (bookId === '0') {
        await api.post('/books', data)
      } else {
        data.id = id
        await api.put(`/books/${id}`, data)
      }
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
          <h1>{bookId === '0' ? 'Adicionar novo livro' : 'Atualizar livro'}</h1>
          <p>Digite as informações do livro e clique em {bookId === '0' ? 'Adicionar' : 'Atualizar'}</p>
          <Link className="back-link" to="/" exact>
            <FiArrowLeft size={16} color="#251fc5" />
            Página Inicial
          </Link>
        </section>

        <form onSubmit={saveOrUpdate}>
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
          <input
            placeholder="Assunto"
            value={subject}
            onChange={e => setSubject(e.target.value)}
          />
          <button className="button" type="submit">{bookId === '0' ? 'Adicionar' : 'Atualizar'}</button>
        </form>
      </div>
    </div>
  )
}